import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Appointment } from '../../models/appointment';
import { AppointmentService } from '../../services/appointment.service';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.sass']
})
export class AppointmentComponent implements OnInit {

  appointments!: Appointment[];
  month!: string;

  constructor(
    private route: ActivatedRoute,
    private appointmentService: AppointmentService
  ) { }

  ngOnInit(): void {
    this.extractMonth();
  }

  private extractMonth() {
    this.route.params.subscribe(parameter => {
      this.month = parameter['id'];
      this.getAppointments();
    });
  }

  private getAppointments() {
      this.appointmentService.getAppointments(this.month).subscribe((appointments) => {
      this.appointments = appointments;
    });
  }

}
