import { NgModule } from "@angular/core";
import { UserFormatPipe } from './pipe/user-format.pipe';

@NgModule({
  imports: [],
  exports: [UserFormatPipe],
  declarations: [UserFormatPipe],
  providers: []
})

export class SharedModule {}
