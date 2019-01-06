import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { UserService } from './../service/user-service.service';
import { ActivatedRoute } from '@angular/router'
import { User } from '../User';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent implements OnInit {

  private userid: string;
  private user: User;
  public errorMessage: string;



  constructor(private _userService: UserService,
    private route : ActivatedRoute) {
    this.route.params.subscribe((params) => {
      this.userid = params['id'];
      console.log(params)
    });
  }

  ngOnInit() {

    if (this.userid != null) {
      this._userService.GetUser(this.userid).subscribe(
        data => this.user = data,
        error => this.errorMessage = error
      );
    }
  }
}
