import BaseComponentObject, {ComponentSettingConfig, FontComponentSettingConfig} from 'BaseCMSManage/Components/BaseComponents/BaseComponent';
import MenuComponentSettingConfig from 'BaseCMSManage/Components/BaseComponents/BaseMenuComponent/MenuComponentSettingConfig'
import ComponentDescribe, { componentType } from 'BaseCMSManage/Components/ComponentDescribe'

class ComponentObject extends BaseComponentObject {
    constructor(component, preview, settingConfig, dataConfig) {
        super();
        this.ComponentSettingConfigs = [
            new MenuComponentSettingConfig(),
            new ComponentSettingConfig(undefined, '组件配置', settingConfig),
            new FontComponentSettingConfig(),
        ];
        this.Component = component;
        this.Preview = preview;
    }
}

const componentDescribeBuilder = (component, preview, settingConfig, dataConfig) =>
    new ComponentDescribe("IEMenu", new ComponentObject(component, preview, settingConfig, dataConfig), componentType.menu, "IE菜单");
export default componentDescribeBuilder;