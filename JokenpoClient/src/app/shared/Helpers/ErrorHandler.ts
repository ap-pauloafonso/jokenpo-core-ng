import { HttpErrorResponse } from '@angular/common/http';
import { Observable} from 'rxjs';
import { throwError } from 'rxjs';

export class ErrorHandler {

    static handle(error: HttpErrorResponse) {
        if (error.status == 400) {
            return throwError(error.error.mensagem);
        } else {
            return throwError(JSON.stringify(error))
        }
    }
}