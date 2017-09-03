import { Component } from '@angular/core';
import { SurveyService } from '../../dataservices/survey.service';
import { ISurvey } from '../../datamodels/survey.model';

@Component({
    selector: 'surveys',
    templateUrl: './surveys.component.html'
})
export class SurveysComponent {
    public surveys: ISurvey[];

    constructor(private surveyService: SurveyService) {
        
        this.surveyService.getSurveys()
        .subscribe((surveys: ISurvey[]) => {
            this.surveys = surveys;
        });
    }
}