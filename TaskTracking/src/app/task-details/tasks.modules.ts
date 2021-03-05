import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { LayoutComponent } from './layout.component';
import { TaskDetailsComponent } from './task-details.component';
import { TaskDetailsFormComponent } from './task-details-form.component';
import { TasksRoutingModule } from './tasks-routing.module';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        TasksRoutingModule,
        RouterModule,
        FormsModule,
    ],
    declarations: [
        LayoutComponent,
        TaskDetailsComponent,
        TaskDetailsFormComponent
    ]
})
export class TasksModule { }