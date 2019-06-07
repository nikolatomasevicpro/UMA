import { ProfileViewModel } from '../response/profile.viewmodel';
import { IRequest } from 'src/app/_models/interfaces/IRequest';

export class GetProfileQuery implements IRequest<ProfileViewModel>  {
  _response?: ProfileViewModel;
  id?: string;
  identityid?: string;
}
