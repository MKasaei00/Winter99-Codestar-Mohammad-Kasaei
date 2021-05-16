import {Component} from '@angular/core';
import {DocumentsService} from '../services/documents.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {

  constructor(private documentsService: DocumentsService) {
  }

  onPingClicked(): void {
    this.documentsService
      .checkConnection()
      .subscribe(value => {
        if (value) {
          alert('Connection to server is OK');
        } else {
          alert('Could not connect to server');
        }
      });
  }
}
