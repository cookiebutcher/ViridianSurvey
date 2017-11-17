import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { ISurvey } from '../datamodels/survey.model';

@Injectable()
export class SurveyService {
    constructor(private http: Http) {

    }

    getSurveys() : Observable<ISurvey[]>{

        return this.http.get('api/v1/surveys')
        .map(res => <ISurvey[]>res.json())
        .catch(err => {
            return Observable.throw(err);
        });        
    }

    getSurveysError(err){

        return Observable.throw(err);
    }
}