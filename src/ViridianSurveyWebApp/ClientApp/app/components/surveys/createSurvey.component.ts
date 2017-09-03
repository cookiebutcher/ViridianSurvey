import { Component } from '@angular/core';
import { SurveyService } from '../../dataservices/survey.service';
import { ISurvey } from '../../datamodels/survey.model';

@Component({
    selector: 'create-survey',
    templateUrl: './createSurvey.component.html'
})
export class CreateSurveyComponent {
    public surveys: ISurvey[];

    constructor(private surveyService: SurveyService) {
        
    }
}