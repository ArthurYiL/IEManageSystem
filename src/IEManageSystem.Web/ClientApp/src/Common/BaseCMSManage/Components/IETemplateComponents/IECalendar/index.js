import BaseComponentObject from '../../BaseComponents/BaseComponent';
import ComponentDescribe, {componentType} from '../../ComponentDescribe'

import IocContainer from 'Core/IocContainer';
import IComponent from './IComponent'
import IPreview from './IPreview'

class ComponentObject extends BaseComponentObject{
    Component=IocContainer.getService(IComponent);
    Preview=IocContainer.getService(IPreview);
}

const componentDescribeBuilder = () => new ComponentDescribe("IECalendar", new ComponentObject(), componentType.other);
export default componentDescribeBuilder;