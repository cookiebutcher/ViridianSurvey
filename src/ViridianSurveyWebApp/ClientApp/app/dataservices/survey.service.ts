import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';
//import 'rxjs/add/operator/map';
//import 'rxjs/add/operator/catch';
import { ISurvey } from '../datamodels/survey.model';

@Injectable()
export class SurveyService {
    constructor(private http: Http) {

    }

    getSurveys() : Observable<ISurvey[]>{

        return this.http.get('api/Survey/Surveys')
        .map(res => <ISurvey[]>res.json())
        .catch(err => {
            return Observable.throw(err);
        });        
    }

    getSurveysError(err){

        return Observable.throw(err);
    }
}