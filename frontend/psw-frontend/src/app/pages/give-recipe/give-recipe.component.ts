import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RecommendAppointmentService } from 'src/app/recommend-appointment.service';
import { DoctorHomePageComponent } from '../doctor-home-page/doctor-home-page.component';
import { RecipeDto } from './recipe.dto';

@Component({
  selector: 'app-give-recipe',
  templateUrl: './give-recipe.component.html',
  styleUrls: ['./give-recipe.component.css']
})
export class GiveRecipeComponent implements OnInit {
  recipeDto: RecipeDto = { Medicine: "", Quantity: "", Instructions: ""}
  recipeForm: FormGroup;
  public id: any = "";
  public idR: any = "";

  constructor(private router: Router, private formBuilder: FormBuilder, private recommendAppointmentService: RecommendAppointmentService) { 
    this.recipeForm = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
  }

  ngOnInit(): void {
    this.recipeForm = this.formBuilder.group({
      Medicine: ['', Validators.required],
      Quantity: ['', Validators.required],
      Instructions: ['', Validators.required]
    });
  }

  Send(){
    console.log(this.idR);
    this.recommendAppointmentService.SendRecipe(this.idR).subscribe((data: any) =>{
      //this.ngOnInit();
      alert("Recipe is sent!");
    });  
  }

}
