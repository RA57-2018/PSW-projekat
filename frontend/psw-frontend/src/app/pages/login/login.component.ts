//import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import jwt_decode from 'jwt-decode';
import { UserService } from 'src/app/user.service';
import { UserDto } from './user.dto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userDto: UserDto = { Username: "", Password: ""}
  public token: any;
  validateForm!: FormGroup;
  hide: boolean = true;
  public decodedToken :any;

  constructor(private route: ActivatedRoute, private fb: FormBuilder, private router: Router, private userService : UserService) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      username: [null, [Validators.required]],
      password: [null, [Validators.required]]
    });
  }

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }

    this.userDto.Username = this.validateForm.value.username;
    this.userDto.Password = this.validateForm.value.password;
    console.log(this.userDto.Username);
    
    this.userService.login(this.userDto).subscribe((data: any)=>{
      localStorage.setItem("jwtToken", data);
      let tokenInfo = this.getDecodedAccessToken(data);
      if(tokenInfo != null){
        console.log(tokenInfo);
        localStorage.setItem('Id', tokenInfo.Id);
        localStorage.setItem('Role', tokenInfo.Role);
        if(tokenInfo.Role == 'PATIENT'){
          this.router.navigate(['patientHomePage']);
        }
      }
      else {
        this.router.navigate(['adminHomePage']);
      }
    });

  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    }
    catch (Error) {
      return null;
    }
  }
  
}
