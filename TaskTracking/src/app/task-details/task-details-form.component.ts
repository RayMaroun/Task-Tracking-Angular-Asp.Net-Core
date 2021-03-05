import { Component, OnInit } from '@angular/core';
import { TaskDetailService } from 'src/app/shared/task-detail.service';
import { NgForm } from '@angular/forms';
import { TaskDetails } from 'src/app/shared/task-detail.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-task-details-form',
  templateUrl: './task-details-form.component.html',
  styles: [
  ]
})
export class TaskDetailsFormComponent implements OnInit {

  constructor(public service: TaskDetailService,private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  onDelete(id: number,form:NgForm) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteTaskDetail(id)
        .subscribe(
          res => {
            this.resetForm(form);
            this.service.refreshList();
            const navigationDetails: string[] = ['tasks'];
            this.router.navigate(navigationDetails);
          },
          err => { console.log(err) }
        )
    }
  }

  insertRecord(form: NgForm) {
    this.service.postTaskDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        const navigationDetails: string[] = ['tasks'];
            this.router.navigate(navigationDetails);
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putTaskDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        const navigationDetails: string[] = ['tasks'];
            this.router.navigate(navigationDetails);
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new TaskDetails();
  }

}
