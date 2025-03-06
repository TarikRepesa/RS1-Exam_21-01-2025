import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import { LoginInformacije } from '../_helpers/login-informacije';
import { AutentifikacijaHelper } from '../_helpers/autentifikacija-helper';

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {

  studentID:any;
  studentiPodaci:any;
  maticnaKnjigaPodaci:any;
  noviUpis:any;
  studentId:any;
  akademskeGodinePodaci:any;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}

  ovjeriLjetni(s:any) { }

  upisLjetni(s:any) { }

  ovjeriZimski(s:any) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      s=>{
        this.studentID = +s["StudentIdParametar"];
      }
    )

    this.ucitajStudenta();
    this.ucitajMaticnuKnjigu();
  }

  ucitajStudenta() {
    this.httpKlijent.get(`${MojConfig.adresa_servera}/ispit/get_student_by_id?Id=${this.studentID}`, MojConfig.http_opcije()).subscribe(x=>{
      this.studentiPodaci = x;
    });
  }

  ucitajMaticnuKnjigu() {
    this.httpKlijent.get(`${MojConfig.adresa_servera}/ispit/get_maticna_knjiga_by_student_id?StudentId=${this.studentID}`, MojConfig.http_opcije()).subscribe(x=>{
      this.maticnaKnjigaPodaci = x;
    });
  }

  zapocniNoviUpis() {
    this.noviUpis = {
      studentId: this.studentID,
      datumUpisa: new Date().toISOString().substring(0,10),
      evidentiraoId: this.loginInfo().autentifikacijaToken.korisnickiNalogId
    };

    this.ucitajAkademskeGodine();
  }

    loginInfo():LoginInformacije {
      return AutentifikacijaHelper.getLoginInfo();
    }

  ucitajAkademskeGodine() {
    this.httpKlijent.get(`${MojConfig.adresa_servera}/AkademskeGodine/GetAll_ForCmb`, MojConfig.http_opcije()).subscribe(x=>{
      this.akademskeGodinePodaci = x;
    });  
  }

  zavrsiUpis() {
    this.httpKlijent.post(`${MojConfig.adresa_servera}/ispit/dodaj_novi_upis`, this.noviUpis, MojConfig.http_opcije()).subscribe(x=>{
      porukaSuccess(`Uspjesno ste dodali novi upis!`);
      this.noviUpis = null;
      this.ucitajMaticnuKnjigu();
    });  
  }

  zatvoriRefresh() {
    this.noviUpis = null;
    this.ucitajMaticnuKnjigu();
  }

  setCijenaObnova() {
    let cijenaSkolarine = 1800;
    let obnova = false;

    for (let i = 0; i < this.maticnaKnjigaPodaci.length; i++) {
      const element = this.maticnaKnjigaPodaci[i];
      
      if(element.godina == this.noviUpis.godina)
      {
        obnova = true;
        cijenaSkolarine = 400;
      }
    } 
    this.noviUpis.cijenaSkolarine = cijenaSkolarine;
     this.noviUpis.obnova = obnova;
  }
}
