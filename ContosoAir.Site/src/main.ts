import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { environment } from './environments/environment';
import { AppModule } from './app/app.module';
import axios from 'axios';

axios('/api/settings').then(response => {
    environment.cloneFrom(response.data);
    if (environment.production) {
        enableProdMode();
    }

    platformBrowserDynamic().bootstrapModule(AppModule);
});
