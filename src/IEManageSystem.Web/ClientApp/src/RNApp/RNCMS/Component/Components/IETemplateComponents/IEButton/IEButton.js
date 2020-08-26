import React from 'react';
import IComponent from 'BaseCMSManage/Components/IETemplateComponents/IEButton/IComponent'
import Setting from 'BaseCMSManage/Components/IETemplateComponents/IEButton/Setting'
import { StyleSheet } from 'react-native'
import { Link, withRouter } from 'react-router-native'
import { Button, Text } from 'native-base'

class IEButton extends IComponent {
    render() {
        let setting = new Setting(this.getSetting("BtnSetting"));

        return (
            <Button
                style={[this.baseStyle, styles.btn]}

                rounded={setting.shape && setting.shape != ''}
                primary={setting.btnType == "primary"}
                warning={setting.btnType == "warning"}
                light={setting.btnType != "primary" && setting.btnType != "warning"}

                small={setting.size == 'small'}
                large={setting.size == 'large'}
                onPress={()=>{
                    this.props.history.push(setting.url);
                }}
            >
                <Text>{setting.text}</Text>
            </Button>
        );

    }
}

const styles = StyleSheet.create({
    btn: {
        flexDirection: 'row',
        justifyContent: 'center',
    }
})

export default (register) => register(IComponent, withRouter(IEButton));