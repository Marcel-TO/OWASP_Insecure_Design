import { Account } from "./Account";

export interface LoggedData {
    log_Id:string,
    data:string,
    acc_Id:string,
    account:Account | null,
}