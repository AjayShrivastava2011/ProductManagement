import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../Model/product.model';
import { ProductService } from '../services/product-service.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  product: Product;

  constructor(private productService: ProductService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.productService.getProductById(id)
      .subscribe(product => this.product = product);
  }

  updateProduct(): void {
    this.productService.updateProduct(this.product.id, this.product)
      .subscribe(() => this.router.navigate(['/products']));
  }

}
