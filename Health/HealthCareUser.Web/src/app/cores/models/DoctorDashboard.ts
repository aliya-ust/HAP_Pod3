
export interface DoctorDashboard {

  upcomingAppointments: number;

  completedAppointments: number;

  upcomingLeaves: number;

  todayAppointments: TodayAppointment[];

}

export interface TodayAppointment {

  slot: string;

}
