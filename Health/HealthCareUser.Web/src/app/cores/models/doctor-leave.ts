export interface CreateLeave {
  leaveDate: string;
  reason: string;
}

export interface CreateLeaveResult {
  skippedDates: string[];
  createdWithCancelledAppointments: string[];
}
