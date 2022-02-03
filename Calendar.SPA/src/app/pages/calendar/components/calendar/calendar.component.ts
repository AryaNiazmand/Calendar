import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Month } from '../../models/month';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.sass']
})
export class CalendarComponent {

  months: Month[] = [
    { value: 1, label: "Jan" },
    { value: 2, label: "Fab" },
    { value: 3, label: "Mar" },
    { value: 4, label: "Apr" },
    { value: 5, label: "May" },
    { value: 6, label: "Jun" },
    { value: 7, label: "Jul" },
    { value: 8, label: "Aug" },
    { value: 9, label: "Sep" },
    { value: 10, label: "Oct" },
    { value: 11, label: "Nov" },
    { value: 12, label: "Dec" }
  ];

  constructor(private router: Router, private activatedRoute: ActivatedRoute) { }

  showAppointments(selectedMonth: any) {
    var month = selectedMonth.option.value;
    this.router.navigate([month], { relativeTo: this.activatedRoute })
  }

}
