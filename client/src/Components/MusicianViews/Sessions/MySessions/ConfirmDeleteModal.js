import React, { useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import deleteIcon from "../../../../images/delete.png";

export const ConfirmDeleteModal = ({session, handleDeleteSession, getFormattedDate}) => {
    const [modal, setModal] = useState(false);

    const toggle = () => setModal(!modal);

    return (
        <div>
            <button 
                className="session-activities-btn"
                onClick={toggle}
            >
                <img 
                    id="remove-activity-icon" 
                    className="remove-icon" 
                    src={deleteIcon} 
                    alt="remove icon" 
                />
            </button>
            <Modal isOpen={modal} toggle={toggle} style={{color:'black'}} size='md'>
                <ModalHeader toggle={toggle}>Warning</ModalHeader>
                <ModalBody >
                    <h5>Are you sure you want to delete session from:</h5>
                    <h4>{getFormattedDate(session.dateCompleted)}</h4>
                    <h5>This action is permanent and cannot be undone.</h5>
                </ModalBody>
                <ModalFooter>
                    <Button 
                        color="info" 
                        value={session.id}
                        onClick={(e) => {handleDeleteSession(e.currentTarget.value * 1); toggle();}}>
                        Delete Session
                    </Button>{' '}
                    <Button 
                        color="secondary"
                        onClick={toggle}
                    >Cancel
                    </Button>
                </ModalFooter>
            </Modal>
        </div>
    )
}