import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentObserveService } from 'src/app/appointment.service';

@Component({
  selector: 'app-doctor-home-page',
  templateUrl: './doctor-home-page.component.html',
  styleUrls: ['./doctor-home-page.component.css']
})
export class DoctorHomePageComponent implements OnInit {
  displayedColumns: string[] = ['id', 'start time', 'patient', 'status', 'giveRecipe'];
  dataSource = [];
  appointmentId: any;
  id: any = "";
  appointments: any[] = [];

  constructor(private route: ActivatedRoute, private router: Router, private _snackBar: MatSnackBar, private observeAppointemntsService: AppointmentObserveService) { }

  ngOnInit(): void {
    this.id = localStorage.getItem('Id');
    console.log(this.id);

    this.observeAppointemntsService.GetDoctorsAppointments(this.id).subscribe((data: any)=>{
      this.dataSource = data;   
    });
  }

  GiveRecipe(element: { idA: number }){}

}
