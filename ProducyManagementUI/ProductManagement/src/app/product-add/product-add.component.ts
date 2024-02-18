import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../Model/product.model';
import { ProductService } from '../services/product-service.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  product: Product = new Product();
  constructor(private productService: ProductService, private router: Router) {
    console.log("Product Add called!");
   }

  ngOnInit(): void {
  }
  addProduct(): void {
    this.productService.addProduct(this.product)
      .subscribe(() => this.router.navigate(['/products']));
  }

}
