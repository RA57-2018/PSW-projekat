import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/user.service';

interface Gender {
  value: string;
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  validateForm!: FormGroup;
  username: string = "";
  name: string = "";
  surname : string = "";
  password : string = "";
  checkPassword : string = "";
  phone : string = "";
  address : string = "";
  jmbg : string = "";
  selectedValueGender = "Male";
  hide: boolean = true;
  hideRp: boolean = true;

  constructor(private fb: FormBuilder,private userService : UserService, private router: Router) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      username: [null,[Validators.required]],
      name: [null, [Validators.required]],
      surname: [null, [Validators.required]],
      password: [null, [Validators.required]],
      checkPassword: [null, [Validators.required, this.confirmationValidator]],
      phone: [null, [Validators.required]],
      address: [null, [Validators.required]],
      jmbg: [null, [Validators.required]]
    });
  }

  confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.validateForm.controls['password'].value) {
      return { confirm: true, error: true };
    }
    return {};
  };

  genders: Gender[] = [
    {value: 'Male'},
    {value: 'Female'}
  ];

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }

    this.username = this.validateForm.value.username;
    this.name = this.validateForm.value.name;
    this.surname = this.validateForm.value.surname;
    this.password = this.validateForm.value.password;
    this.phone = this.validateForm.value.phone;
    this.address = this.validateForm.value.address;
    this.jmbg = this.validateForm.value.jmbg;

      const body = {
        name: this.name,
        surname: this.surname,
        username: this.username,
        password : this.password,
        phone : this.phone,
        jmbg : this.jmbg,
        address : this.address,
        gender: this.selectedValueGender
      }

      if(this.validateForm.valid){
        this.userService.registration(body).subscribe(data => { 
            alert("Registration successfull");
           // this.router.navigate(['login']);
        }, error => {
          console.log(error.status);
          if(error.status == 409){
            alert("Username already exists");
          }
        });
      }
    }
}
