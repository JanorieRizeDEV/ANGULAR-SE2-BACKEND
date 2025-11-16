import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { TarjetaService } from '../services/tarjeta.service';

@Component({
  selector: 'app-tarjeta',
  templateUrl: './tarjeta.component.html'
})
export class TarjetaComponent implements OnInit, OnDestroy {
  form!: FormGroup;
  private cvvSub?: Subscription;

  constructor(private fb: FormBuilder, private tarjetaSvc: TarjetaService) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      titular: ['', Validators.required],
      numeroTarjeta: ['', [Validators.required]],
      fechaExpiracion: ['', Validators.required],
      cvv: ['', [Validators.required, Validators.pattern('^[0-9]{3,4}$')]]
    });

    // Forzar tipo number en el control CVV en cuanto cambie (no emite evento para evitar bucles)
    this.cvvSub = this.form.get('cvv')!.valueChanges.subscribe(v => {
      if (v === null || v === '') return;
      const parsed = typeof v === 'number' ? v : Number(String(v).replace(/\D/g, ''));
      if (parsed !== v) {
        this.form.get('cvv')!.setValue(parsed, { emitEvent: false });
      }
    });
  }

  ngOnDestroy(): void {
    this.cvvSub?.unsubscribe();
  }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    // snapshot seguro
    const payload = { ...this.form.value, cvv: Number(this.form.value.cvv) };

    this.tarjetaSvc.addTarjeta(payload).subscribe({
      next: res => console.log('Tarjeta guardada', res),
      error: err => console.error('Error al guardar tarjeta', err)
    });
  }
}