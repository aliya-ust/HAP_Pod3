using System;
using System.Numerics;
using System.Text;
using HealthApp.ConsoleApp.Models;

public class Appointment
{
    public int AppointmentId { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string TimeSlot { get; set; }
    public AppointmentStatus Status { get; set; }
    public string CancellationReason { get; set; }
   
    public Appointment()
    {
        Status = AppointmentStatus.Pending;
    }

    
    public void Confirm()
    {
        if (Status == AppointmentStatus.Cancelled)
        {
            throw new InvalidOperationException("Cannot confirm a cancelled appointment.");
        }

        Status = AppointmentStatus.Confirmed;
    }

    
    public void Cancel(string reason)
    {
        if (Status == AppointmentStatus.Completed)
        {
            throw new InvalidOperationException("Cannot cancel a completed appointment.");
        }

        Status = AppointmentStatus.Cancelled;
        CancellationReason = reason;
    }

    
    public void Complete()
    {
        if (Status != AppointmentStatus.Confirmed)
        {
            throw new InvalidOperationException("Only confirmed appointments can be completed.");
        }

        Status = AppointmentStatus.Completed;
    }

   
    public string GetDetails()
    {
        StringBuilder details = new StringBuilder();

        details.AppendLine($"Appointment ID: {AppointmentId}");
        details.AppendLine($"Patient: {Patient?.FullName}");
        details.AppendLine($"Doctor: {Doctor?.FullName} ({Doctor?.Specialisation})");
        details.AppendLine($"Date: {ScheduledDate.ToShortDateString()}");
        details.AppendLine($"Time Slot: {TimeSlot}");
        details.AppendLine($"Status: {Status}");

        if (!string.IsNullOrEmpty(CancellationReason))
        {
            details.AppendLine($"Cancellation Reason: {CancellationReason}");
        }

        return details.ToString();
    }
}