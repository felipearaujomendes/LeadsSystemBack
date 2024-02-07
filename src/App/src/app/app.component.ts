import { Component,OnInit,ElementRef, ViewChild } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {STEPPER_GLOBAL_OPTIONS} from '@angular/cdk/stepper';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import {FormControl} from '@angular/forms';
import {MatAutocompleteSelectedEvent, MatAutocomplete} from '@angular/material/autocomplete';
import {MatChipInputEvent} from '@angular/material/chips';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [{
    provide: STEPPER_GLOBAL_OPTIONS, useValue: {displayDefaultIndicatorType: false}
  }]
})
export class AppComponent implements OnInit {
    
  formResult: string = '';
  briefing : any;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  dadosempresa: FormGroup;
  constructor(private _formBuilder: FormBuilder) {

    
  }


  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
  }
  Cadastrar() {
    if (this.dadosempresa.dirty && this.dadosempresa.valid) {
      this.briefing = Object.assign({}, this.briefing, this.dadosempresa.value);
      this.formResult = JSON.stringify(this.dadosempresa.value);
    }
    else {
      this.formResult = "Não submeteu!!!"
    }
  }
}
