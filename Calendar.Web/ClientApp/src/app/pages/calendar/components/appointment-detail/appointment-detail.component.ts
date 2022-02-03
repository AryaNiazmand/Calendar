import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppointmentDetail } from '../../models/appointment-detail';
import { AppointmentService } from '../../services/appointment.service';

@Component({
  selector: 'app-appointment-detail',
  templateUrl: './appointment-detail.component.html',
  styleUrls: ['./appointment-detail.component.sass']
})
export class AppointmentDetailComponent implements OnInit {

  appointmentDetail!: AppointmentDetail;
  appointmentId!: string;

  constructor(
    private route: ActivatedRoute,
    private appointmentService: AppointmentService
  ) { }

  ngOnInit(): void {
    this.extractAppointmentId();
  }

  private extractAppointmentId() {
    this.route.params.subscribe(parameter => {
      this.appointmentId = parameter['id'];
      this.getAppointmentDetail();
    });
  }

  private getAppointmentDetail() {
      this.appointmentService.getAppointmentDetail(this.appointmentId).subscribe((appointmentDetail) => {
      this.appointmentDetail = appointmentDetail;
    });
  }

}
