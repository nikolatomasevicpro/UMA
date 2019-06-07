import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { IdentitiesViewModel } from '../response/identities.viewmodel';

export class GetAllIdentitiesQuery implements IRequest<IdentitiesViewModel> {
  _response?: IdentitiesViewModel;
}
