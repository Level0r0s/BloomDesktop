﻿class TalkingBookModel implements ITabModel {
    restoreSettings(settings: string) {}

    configureElements(container: HTMLElement) {}

    showTool() {
        initializeTalkingBookTool();
        audioRecorder.setupForRecording();
    }

    hideTool() {
        audioRecorder.removeRecordingSetup();
    }

    updateMarkup() {
        audioRecorder.updateMarkupAndControlsToCurrentText();
    }

    name() { return 'talkingBookTool'; }
}

tabModels.push(new TalkingBookModel());
