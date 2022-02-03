import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CalendarRoutingModule } from './calendar-routing.module';
import { AppointmentComponent } from './components/appointment/appointment.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { AppointmentDetailComponent } from './components/appointment-detail/appointment-detail.component';
import {SelectButtonModule} from 'primeng/selectbutton';
import {ListboxModule} from 'primeng/listbox';
import { HttpClientModule } from '@angular/common/http';
import {CardModule} from 'primeng/card';
import { AppointmentService } from './services/appointment.service';
import { FlexLayoutModule } from "@angular/flex-layout";


@NgModule({
  declarations: [
    AppointmentComponent,
    CalendarComponent,
    AppointmentDetailComponent,
  ],
  providers:[AppointmentService],
  imports: [
    CommonModule,
    HttpClientModule,
    CalendarRoutingModule,
    SelectButtonModule,
    ListboxModule,
    CardModule,
    FlexLayoutModule
  ],
  
})
export class CalendarModule { }
