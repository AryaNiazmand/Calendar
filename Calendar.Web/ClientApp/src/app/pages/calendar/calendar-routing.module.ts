import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentDetailComponent } from './components/appointment-detail/appointment-detail.component';
import { AppointmentComponent } from './components/appointment/appointment.component';
import { CalendarComponent } from './components/calendar/calendar.component';

const routes: Routes = [
  {
    path: "",
    component: CalendarComponent,
    children: [
      {
        path: ":id", component: AppointmentComponent,
        children: [
          { path: "appointment/:id", component: AppointmentDetailComponent, }
        ]
      },

    ]
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CalendarRoutingModule { }
