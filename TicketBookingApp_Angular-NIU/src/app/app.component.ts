import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
    template: `<h1>{{name}}</h1> <br/>
               <h2>{{name2}}<h2>`,
})
export class AppComponent  {
    name = 'Welcome to Ticketing App';
    name2 = 'sign in';
}
