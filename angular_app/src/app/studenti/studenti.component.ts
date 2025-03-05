import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import { ComboBox_Opcije } from '../_helpers/combobox-opcije';
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;
  filterDatumRodjenja: any = '0';
  combobox_opcije = ComboBox_Opcije.opcije;

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  fetchStudenti() :void
  {
    this.httpKlijent.get(`${MojConfig.adresa_servera}/Student/GetAll?filterDatumRodjenja=${this.filterDatumRodjenja != 0 ? this.filterDatumRodjenja : ""}`, MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  ngOnInit(): void {
    this.fetchStudenti();
  }

  filtrirajDatum() {
    this.fetchStudenti();
  }
}
