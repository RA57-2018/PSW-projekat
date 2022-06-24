import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-patient-home-page',
  templateUrl: './patient-home-page.component.html',
  styleUrls: ['./patient-home-page.component.css']
})
export class PatientHomePageComponent implements OnInit {
  public token: any;
  public decodedToken: any;

  constructor(private route: ActivatedRoute, private router: Router) {} 

  ngOnInit(): void {
  
  }

}


