import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { UpdateProfileViewModel } from '../response/updateProfile.viewmodel';

export class UpdateProfileQuery implements IRequest<UpdateProfileViewModel> {
  _response?: UpdateProfileViewModel;
  id: string;
  locale?: string;
}
