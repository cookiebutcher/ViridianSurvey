import { Component } from '@angular/core';
import { SurveyService } from '../../dataservices/survey.service';
import { ISurvey } from '../../datamodels/survey.model';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public surveys: ISurvey[];

    constructor(     
        private surveyService: SurveyService) {
        
        this.surveyService.getSurveys()
        .subscribe((surveys: ISurvey[]) => {
            this.surveys = surveys;
        });
    }
}