import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LayoutComponent } from './layout.component';
import { TaskDetails } from '../shared/task-detail.model';
import { TaskDetailsComponent } from './task-details.component';
import { TaskDetailsFormComponent } from './task-details-form.component';

const routes: Routes = [
    {
        path: '', component: LayoutComponent,
        children: [
            { path: '', component: TaskDetailsComponent },
            { path: 'add', component: TaskDetailsFormComponent },
            { path: 'edit/:id', component: TaskDetailsFormComponent }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TasksRoutingModule { }