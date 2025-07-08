import { HttpEvent, HttpEventType, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { LoaderService } from "../services/loader/loader-service";
import { finalize, Observable, tap } from "rxjs";



export const loaderInterceptor: HttpInterceptorFn = (req, next) => {
  const loaderService = inject(LoaderService);

  console.log(`[Loader] 🚀 Sending request: ${req.url}`);
  loaderService.show();

  return next(req).pipe(
    tap({
      next: (event) => {
        if (event.type === HttpEventType.Response) {
          console.log(`[Loader] 📥 Response received for: ${req.url}`);
        }
      },
      error: (err) => {
        console.log(`[Loader] ❌ Error received for: ${req.url}`, err);
      }
    }),
    finalize(() => {
      console.log(`[Loader] 🔻 Finalize (hiding loader): ${req.url}`);
      loaderService.hide();
    })
  );
};
