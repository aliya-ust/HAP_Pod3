
using System;
using System.Text.RegularExpressions;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Menus
{
    public class PatientMenu
    {
        private readonly IPatientService _service;

        public PatientMenu(IPatientService service)
        {
            _service = service;
        }

        // ✅ CENTRALIZED EXCEPTION HANDLER
        private void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (PatientInvalidException ex)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"⚠️ {ex.Message}");
            }
            catch (PatientNotFoundException ex)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"❌ {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"⚠️ {ex.Message}");
            }
        }

        // ✅ MAIN MENU
        public void PatientRegisteration()
        {
            while (true)
            {
                Console.WriteLine("\n======================================");
                Console.WriteLine("           PATIENT MENU");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. View All Patients");
                Console.WriteLine("4. Profile Summary By Id");
                Console.WriteLine("5. Exit");

                // Console.WriteLine("3. Get Patient By Id");
                // Console.WriteLine("4. Delete Patient");

                int choice = ReadInt("Enter choice: ");
                Console.WriteLine("--------------------------------------");
                switch (choice)
                {
                    case 1: Execute(AddPatient); break;
                    case 2: Execute(UpdatePatient); break;
                    //case 3: Execute(GetPatientById); break;
                    //case 4: Execute(DeletePatient); break;
                    case 3: Execute(ViewAll); break;
                    case 4: Execute(GetProfile); break;
                    case 5: return;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }

        // INPUT HELPERS  FOR VALIDATION
        private string ReadNonEmpty(string msg)
        {
            string input;
            do
            {
                Console.Write(msg);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private string ReadOptional(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }
        private int ReadInt(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (int.TryParse(Console.ReadLine(), out int val))
                    return val;

                Console.WriteLine("Invalid number");
            }
        }
        private DateTime ReadDate(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }

                Console.WriteLine("Invalid format (dd/MM/yyyy)");
            }
        }
        private string ReadEmail()
        {
            while (true)
            {
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    return email;

                Console.WriteLine("Invalid email");
            }
        }
        private string ReadPhone()
        {
            while (true)
            {
                Console.Write("Enter Phone (10 digits): ");
                string phone = Console.ReadLine();

                if (Regex.IsMatch(phone, @"^\d{10}$"))
                    return phone;

                Console.WriteLine("Invalid phone");
            }
        }

        private Patient.GenderType ReadGender()
        {
            while (true)
            {
                Console.Write("Enter Gender (Male/Female/Other): ");

                if (Enum.TryParse(Console.ReadLine(), true,
                    out Patient.GenderType gender))
                    return gender;

                Console.WriteLine("Invalid gender");
            }
        }

        // MENU OPERATIONS
        private void AddPatient()
        {
            var p = new Patient
            {
                Name = ReadNonEmpty("Enter Name: "),
                Dob = ReadDate("Enter DOB (dd/MM/yyyy): "),
                Gender = ReadGender(),
                PhoneNumber = ReadPhone(),
                Email = ReadEmail(),
                InsuranceId = ReadInt("Enter Insurance Id: ")
            };

            _service.AddPatient(p);

            Console.WriteLine("\n✅ Patient Registered Successfully");
            Console.WriteLine(p.GetProfileSummary());
        }

        private void UpdatePatient()
        {
            int id = ReadInt("Enter Patient Id: ");
            var p = _service.GetPatientById(id);

            Console.WriteLine("\n🔔 Update Instructions:");
            Console.WriteLine("Press ENTER to keep existing value.");
            Console.WriteLine("Enter new value to update.\n");

            // ✅ NAME
            string name = ReadOptional($"Name ({p.Name}): ");
            if (!string.IsNullOrWhiteSpace(name))
                p.Name = name;

            // ✅ DOB (LOOP UNTIL VALID OR EMPTY)
            while (true)
            {
                string dobInput = ReadOptional($"DOB ({p.Dob:dd/MM/yyyy}): ");

                if (string.IsNullOrWhiteSpace(dobInput))
                    break;

                if (DateTime.TryParseExact(dobInput, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out DateTime dob)
                    && dob <= DateTime.Now)
                {
                    p.Dob = dob;
                    break;
                }

                Console.WriteLine("❌ Invalid DOB. Please enter again.");
            }

            // ✅ GENDER
            while (true)
            {
                string genderInput = ReadOptional($"Gender ({p.Gender}): ");

                if (string.IsNullOrWhiteSpace(genderInput))
                    break;

                if (Enum.TryParse(genderInput, true, out Patient.GenderType gender))
                {
                    p.Gender = gender;
                    break;
                }

                Console.WriteLine("❌ Invalid Gender. Try again (Male/Female/Other).");
            }

            // ✅ PHONE
            while (true)
            {
                string phone = ReadOptional($"Phone ({p.PhoneNumber}): ");

                if (string.IsNullOrWhiteSpace(phone))
                    break;

                if (Regex.IsMatch(phone, @"^\d{10}$"))
                {
                    p.PhoneNumber = phone;
                    break;
                }

                Console.WriteLine("❌ Invalid Phone (must be 10 digits). Try again.");
            }

            // ✅ EMAIL
            while (true)
            {
                string email = ReadOptional($"Email ({p.Email}): ");

                if (string.IsNullOrWhiteSpace(email))
                    break;

                if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    p.Email = email;
                    break;
                }

                Console.WriteLine("❌ Invalid Email. Try again.");
            }

            // ✅ INSURANCE ID
            while (true)
            {
                string insInput = ReadOptional($"Insurance Id ({p.InsuranceId}): ");

                if (string.IsNullOrWhiteSpace(insInput))
                    break;

                if (int.TryParse(insInput, out int ins))
                {
                    p.InsuranceId = ins;
                    break;
                }

                Console.WriteLine("❌ Invalid number. Try again.");
            }

            _service.UpdatePatient(p);

            Console.WriteLine("\n✅ Patient Updated Successfully");
        }

        private void ViewAll()
        {
            var patients = _service.GetAllPatients();

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found");
                return;
            }

            foreach (var p in patients)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine(p.GetProfileSummary());
            }
        }

        private void GetProfile()
        {
            int id = ReadInt("Enter Patient Id: ");
            string summary = _service.GetPatientProfileSummary(id);

            Console.WriteLine(summary);
        }

        //private void DeletePatient()
        //{
        //    int id = ReadInt("Enter Patient Id: ");
        //    _service.DeletePatient(id);

        //    Console.WriteLine("✅ Patient Deleted Successfully");
        //}

        //private void GetPatientById()
        //{
        //    int id = ReadInt("Enter Patient Id: ");
        //    var p = _service.GetPatientById(id);

        //    Console.WriteLine(p.GetProfileSummary());
        //}
    }
}
