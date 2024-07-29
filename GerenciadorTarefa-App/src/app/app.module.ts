import { AppComponent } from "./app.component";
import { LoginComponent } from './login/login.component';
import { AngularMaterialModule } from './angular-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  declarations: [	AppComponent,
                  LoginComponent
   ],
  imports: [BrowserModule,
           FormsModule,
           AngularMaterialModule,
           BrowserAnimationsModule,
           FlexLayoutModule,
           ReactiveFormsModule],
  providers: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {

}
