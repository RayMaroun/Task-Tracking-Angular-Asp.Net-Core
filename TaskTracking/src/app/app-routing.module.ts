import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const tasksModule = () => import('./task-details/tasks.modules').then(x => x.TasksModule);

const routes: Routes = [
    { path: 'tasks', loadChildren: tasksModule },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }