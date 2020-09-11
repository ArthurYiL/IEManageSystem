import Component from './Component'
import Preview from './Preview'
import describeBuilder from 'IETemplateComponents/IERankingList'
import RNComponent from 'RNIETemplateComponents/IERankingList/Component'

export const RNDescribe = (RNComponent, Preview);
export default describeBuilder(Component, Preview);