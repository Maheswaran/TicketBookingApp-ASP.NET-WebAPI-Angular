import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { UserService } from './service/user-service.service';
import { User } from './../user/user';
import { Console } from '@angular/core/src/console';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { error } from 'util';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  providers: [ UserService],
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  public users: User[];
  public errorMessage: string;
  public conversionForm : FormGroup;


  constructor(private _userService: UserService,
    private fb: FormBuilder) {

   
  }

  ngOnInit() {

    this._userService.GetUsers().subscribe((data) => {
      this.users = <User[]>data;
    },
    error => this.errorMessage = error);   
  }  
}
