import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from 'src/app/_services/_base/config/configuration.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {
  title = this.conf.config.appTitle;

  constructor(
    private conf: ConfigurationService
  ) { }

  ngOnInit() {
  }
}
