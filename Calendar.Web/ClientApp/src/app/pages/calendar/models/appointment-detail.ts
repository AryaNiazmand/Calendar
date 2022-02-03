import { Appointment } from "./appointment";
import { User } from "./user";

export class AppointmentDetail  extends Appointment {
    public organizer!: string;
    public attendees!: User[];
    public appointment!:Appointment;
}