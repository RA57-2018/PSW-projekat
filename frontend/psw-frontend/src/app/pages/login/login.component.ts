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
  token: string = "";
  validateForm!: FormGroup;
  hide: boolean = true;

  constructor(private route: ActivatedRoute, private fb: FormBuilder, private router: Router, private userService : UserService) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      username: [null, [Validators.required]],
      password: [null, [Validators.required]]
    });

    
   /* const token = this.route.snapshot.params['token'];
    if (token != undefined) {
      this.rrService.confirmRegistrationRequest(token).subscribe(() => {
        this.router.navigateByUrl(`/login`);
      },
        error => {
        });
    }*/
  }

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }

    this.userDto.Username = this.validateForm.value.username;
    this.userDto.Password = this.validateForm.value.password;
    console.log(this.userDto.Username)

    this.userService.login(this.userDto).subscribe((data: any)=>{
      localStorage.setItem("jwtToken", data);
      let tokenInfo = this.getDecodedAccessToken(data);
      localStorage.setItem('id', tokenInfo.id);
      localStorage.setItem('role', tokenInfo.role);
      console.log(tokenInfo.role);
      console.log(data);
      this.router.navigate(['patientHomePage']);
    });

   /* this.userService.login(this.userDto).subscribe(data => {
      const user = data;
      localStorage.setItem('user', JSON.stringify(user));
      localStorage.setItem('token', JSON.stringify(user.token));
      console.log(user.token)

      sessionStorage.setItem('username', user.username);
      let authString = 'Basic ' + btoa(user.username + ':' + user.password);
      sessionStorage.setItem('basicauth', authString);

      if(this.getDecodedAccessToken(data.token).role === 'PATIENT'){
        console.log(this.getDecodedAccessToken(data.token).role)
        this.router.navigate(['patientHomePage']);
      }
    }, error => {
      alert("Error");
    })*/
  }

  getDecodedAccessToken(token: string): any {
    try {
      console.log(token)
      return jwt_decode(token);
    }
    catch (Error) {
      token = "";
    }
  }

}
