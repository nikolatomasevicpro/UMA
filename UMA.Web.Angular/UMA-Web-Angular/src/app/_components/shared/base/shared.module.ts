import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GlobalDirective } from 'src/app/_directives/global/global.directive';

@NgModule({
  declarations: [
    GlobalDirective
  ],
  imports: [
    CommonModule
  ],
  exports: [GlobalDirective]
})
export class SharedModule { }
