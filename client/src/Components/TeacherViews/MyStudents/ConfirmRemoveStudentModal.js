import React, { useEffect, useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import "./Students.css";
import { getUserById } from '../../../Managers/profileManager';

export const ConfirmRemoveStudentModal = ({ studentId, handleRemoveStudent }) => {
    const [modal, setModal] = useState(false);
    const [student, setStudent] = useState({});

    useEffect(() => {
        getUserById(studentId).then(setStudent);
    }, [studentId])

    const toggle = () => setModal(!modal);

    return (
        <div className='remove-btn'>
            <Button 
                color="secondary" 
                size="sm" 
                className="student-table-btn"
                value={studentId}
                onClick={toggle}
            >Remove
            </Button>
            <Modal isOpen={modal} toggle={toggle} style={{color:'black'}} size='md'>
                <ModalHeader toggle={toggle}>Warning</ModalHeader>
                <ModalBody >
                    <h5>Are you sure you want to remove {student?.firstName} from your list of students?</h5>
                    <p>You will no longer be able to view content or assign sessions to this student.
                        The student will need to update their profile to undo this action.</p>
                </ModalBody>
                <ModalFooter>
                    <Button 
                        color="info" 
                        value={studentId}
                        onClick={(e) => {handleRemoveStudent(e); toggle();}}>
                        Remove
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