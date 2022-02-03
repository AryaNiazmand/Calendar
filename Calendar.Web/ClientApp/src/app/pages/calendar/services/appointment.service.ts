import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Appointment } from '../models/appointment';
import { AppointmentDetail } from '../models/appointment-detail';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  hostUrl="http://localhost:5000/api";

  constructor(private http: HttpClient) { }

  public getAppointments(month:string){
    return this.http.get<Appointment[]>(`${this.hostUrl}/appointments/${month}`);
  }

  public getAppointmentDetail(appointmentId:string){
    return this.http.get<AppointmentDetail>(`${this.hostUrl}/appointments/${appointmentId}/appointment-detail`);
  }

}
