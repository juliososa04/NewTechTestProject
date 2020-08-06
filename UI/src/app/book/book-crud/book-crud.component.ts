import { Component, OnInit } from '@angular/core';
import { BookrepositoryService } from 'src/app/services/book/bookrepository.service';
import { MatDialogRef } from '@angular/material';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-book-crud',
  templateUrl: './book-crud.component.html',
  styleUrls: ['./book-crud.component.css']
})
export class BookCrudComponent implements OnInit {

  constructor(private service: BookrepositoryService,private notificationService: NotificationService,public dialogRef: MatDialogRef<BookCrudComponent>) { }

  ngOnInit() {
  }
   
  onClose() {
    this.service.form.reset();
    this.service.initializeForm();
    this.dialogRef.close();
  }
    //reset form
  onClear() {
      this.service.form.reset();
      this.service.initializeForm();
  }
  onSubmit() {
    if (this.service.form.valid) {
      if (!this.service.form.get('ID').value)
        this.service.CreateBook(this.service.form.value).subscribe(res => {
          this.onClear();
          this.onClose();
          this.service.refressList().subscribe(res => {
    
            this.service.list = res;
            this.notificationService.success('Saved successfully');
          })
        });
      else
        this.service.UpdateBook(this.service.form.value).subscribe(res => {
          this.onClear();
          this.onClose();
          this.service.refressList().subscribe(res => {
            this.service.list = res;
            this.notificationService.success('Updated successfully');
          });
        });

    }
  }
}
