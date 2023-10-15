import { Component, OnInit } from '@angular/core';
import { LoadingService } from './services/loading.service';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  loading: boolean = false;
  title = 'Trabalho de Conclusão de Curso';

  constructor(private loadingService: LoadingService) {

  }

  ngOnInit(): void {
    this.listenToLoading();
  }

  private listenToLoading(): void {
    this.loadingService.loadingSub
      .pipe(delay(0))
      .subscribe((loading) => {
        this.loading = loading as boolean;
      });
  }
}
