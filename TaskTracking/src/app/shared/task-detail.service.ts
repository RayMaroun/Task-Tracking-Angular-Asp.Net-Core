import { Injectable } from '@angular/core';
import { TaskDetails } from './task-detail.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TaskDetailService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'https://localhost:44388/api/TaskDetails'
  formData: TaskDetails = new TaskDetails();
  list: TaskDetails[];

  postTaskDetail() {
    return this.http.post(this.baseURL, this.formData);
  }

  putTaskDetail() {
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

  deleteTaskDetail(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res => this.list = res as TaskDetails[]);
  }


}
