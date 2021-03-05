import { Component, OnInit } from '@angular/core';
import { TaskDetails } from '../shared/task-detail.model';
import { TaskDetailService } from '../shared/task-detail.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html'
})
export class TaskDetailsComponent implements OnInit {

  constructor(public service: TaskDetailService,private router: Router) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: TaskDetails) {
    const navigationDetails: string[] = ['tasks/edit/'+selectedRecord.id];
    this.service.formData = Object.assign({}, selectedRecord);
    this.router.navigate(navigationDetails);
  }

  addTask(){
    const navigationDetails: string[] = ['tasks/add'];
    this.service.formData = new TaskDetails();
    this.router.navigate(navigationDetails);
  }

  

}
